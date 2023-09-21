import { Button, Modal } from "react-bootstrap";
import React, { useEffect, useState } from "react";
import { Driver } from "../../../core/api/types";
import { GetDriverById } from "../../../core/api/DriverManagement/DriverManagment";
import { useNavigate } from "react-router-dom";
import { Triangle } from "react-loader-spinner";
import { Container } from "../../pages/register/styles";
import moment from "moment";
import * as S from "./styles";

type DeleteModalProps = {
  id: string;
  show: boolean;
  handleClose: () => void;
};

function DetailModal(proops: DeleteModalProps): React.JSX.Element {
  const [driverLoaded, setDriverLoaded] = useState<Driver>();
  const [age, setAge] = useState<number>(0);

  function idade(birthDate: Date) {
    const today = new Date();
    let age = today.getFullYear() - new Date(birthDate).getFullYear();
    const month = today.getMonth() - new Date(birthDate).getMonth();
    if (
      month < 0 ||
      (month === 0 && today.getDate() < new Date(birthDate).getDate())
    ) {
      age--;
    }

    console.log(age);
    setAge(age);
  }

  const navigate = useNavigate();

  useEffect(() => {
    async function getDriver() {
      try {
        const driver = await GetDriverById({ id: proops.id });
        setDriverLoaded(driver);
        idade(driver.dateOfBirth);
      } catch (error) {
        proops.handleClose();
      }
    }
    getDriver();
  }, [proops, navigate]);

  return (
    <div
      className="modal show"
      style={{ display: "block", position: "initial" }}
    >
      <Modal
        show={proops.show}
        onHide={proops.handleClose}
        aria-labelledby="modal-dialog modal-dialog-centered"
        centered
      >
        <Modal.Header>
          <Modal.Title>Detalhes do Motorista</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {!driverLoaded ? (
            <Container>
              <Triangle
                height="80"
                width="80"
                color="#1c02af"
                ariaLabel="triangle-loading"
                wrapperStyle={{}}
                visible={true}
              />
            </Container>
          ) : (
            <S.ModalBody>
              <S.ModalTitle>{driverLoaded.name}</S.ModalTitle>
              <S.ModalCardContainer>
                <S.ModalCard>
                  <S.ModalCardTitle>Email</S.ModalCardTitle>
                  {driverLoaded.email}
                </S.ModalCard>
                <S.ModalCard>
                  <S.ModalCardTitle>Cidade</S.ModalCardTitle>
                  {driverLoaded.city}
                </S.ModalCard>
                <S.ModalCard>
                  <S.ModalCardTitle>Nascimento</S.ModalCardTitle>
                  {moment(driverLoaded.dateOfBirth).format("DD-MM-YYYY")}
                </S.ModalCard>
                <S.ModalCard>
                  <S.ModalCardTitle>Idade</S.ModalCardTitle>
                  {`${age} anos`}
                </S.ModalCard>
                <S.ModalCard>
                  <S.ModalCardTitle>CNH</S.ModalCardTitle>
                  {driverLoaded.drivingLicenseNumber}
                </S.ModalCard>
                <S.ModalCard>
                  <S.ModalCardTitle>Validade CNH</S.ModalCardTitle>
                  {moment(driverLoaded.drivingLicenseExpirationDate).format(
                    "DD-MM-YYYY"
                  )}
                </S.ModalCard>
              </S.ModalCardContainer>
            </S.ModalBody>
          )}
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={proops.handleClose}>
            Sair
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}

export default DetailModal;
