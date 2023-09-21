import React, { useEffect, useState } from "react";
import * as S from "./styles";
import { Form, Button, Row, Col } from "react-bootstrap";
import { useNavigate, useParams } from "react-router-dom";
import { toast } from "react-toastify";
import {
  UpdateDriver,
  GetDriverById,
} from "../../../core/api/DriverManagement/DriverManagment";
import { Driver } from "../../../core/api/types";
import { UpdateDriverInput } from "../../../core/api/DriverManagement/interfaces/UpdateDriver.interface";
import { Triangle } from "react-loader-spinner";
import { Container, Title } from "../../styles/globalStyles";
import moment from "moment";

export default function UpdatePage(): React.JSX.Element {
  const [validated, setValidated] = useState(false);
  const [name, setName] = useState<string>("");
  const [birthDate, setBirthDate] = useState<string>("");
  const [drivingLicenseNumber, setDrivingLicenseNumber] = useState<string>("");
  const [drivingLicenseExpirationDate, setDrivingLicenseExpirationDate] =
    useState<string>("");
  const [email, setEmail] = useState<string>("");
  const [city, setCity] = useState<string>("");

  const [driverLoaded, setDriverLoaded] = useState<Driver>();

  const navigate = useNavigate();

  const params = useParams();

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const handleSubmit = async (event: any) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
      setValidated(true);
    } else {
      try {
        setValidated(true);
        event.preventDefault();

        const driver: UpdateDriverInput = {
          id: params.id!,
          name: name === "" ? driverLoaded!.name : name,
          dateOfBirth:
            birthDate === ""
              ? driverLoaded!.dateOfBirth
              : handleDate(birthDate),
          drivingLicenseNumber:
            drivingLicenseNumber === ""
              ? driverLoaded!.drivingLicenseNumber
              : drivingLicenseNumber,
          drivingLicenseExpirationDate:
            drivingLicenseExpirationDate === ""
              ? driverLoaded!.drivingLicenseExpirationDate
              : handleDate(drivingLicenseExpirationDate),
          email: email === "" ? driverLoaded!.email : email,
          city: city === "" ? driverLoaded!.city : city,
        };

        await UpdateDriver(driver);
        toast.success(`Motorista ${name} editado com sucesso`);
        navigate("/");
      } catch (error) {
        toast.error("Não foi possível editar o motorista");
      }
    }
  };

  const handleDate = (date: string) => {
    const dateSplit = date.split("-");
    const day = Number(dateSplit[2]);
    const month = Number(dateSplit[1]);
    const year = Number(dateSplit[0]);
    const stringToDate = new Date(year, month - 1, day);

    return stringToDate;
  };

  useEffect(() => {
    async function getDriver() {
      try {
        const driver = await GetDriverById({ id: params.id! });
        setDriverLoaded(driver);
      } catch (error) {
        navigate("/");
      }
    }
    getDriver();
  }, [params.id, navigate]);

  return (
    <React.Fragment>
      <Title>Editar motorista</Title>
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
        <Container>
          <S.FormBase>
            <Form noValidate validated={validated} onSubmit={handleSubmit}>
              <Row className="mb-1">
                <Form.Group as={Col} md="12" controlId="validationName">
                  <Form.Label>Nome</Form.Label>
                  <Form.Control
                    required
                    type="text"
                    value={name === "" ? driverLoaded?.name : name}
                    onChange={(e) => setName(e.target.value)}
                  />
                </Form.Group>
              </Row>
              <Row className="mb-1">
                <Form.Group as={Col} md="12" controlId="validationBirthDate">
                  <Form.Label>Data de Nascimento</Form.Label>
                  <Form.Control
                    required
                    type="date"
                    value={
                      birthDate === ""
                        ? moment(driverLoaded.dateOfBirth).format("YYYY-MM-DD")
                        : birthDate
                    }
                    onChange={(e) => setBirthDate(e.target.value)}
                  />
                </Form.Group>
              </Row>
              <Row className="mb-1">
                <Form.Group
                  as={Col}
                  md="12"
                  controlId="validationDrivingLicenseNumber"
                >
                  <Form.Label>Numero da CNH</Form.Label>
                  <Form.Control
                    required
                    type="text"
                    placeholder="Numero da CNH"
                    value={
                      drivingLicenseNumber === ""
                        ? driverLoaded?.drivingLicenseNumber
                        : drivingLicenseNumber
                    }
                    onChange={(e) => setDrivingLicenseNumber(e.target.value)}
                  />
                </Form.Group>
              </Row>
              <Row className="mb-1">
                <Form.Group
                  as={Col}
                  md="12"
                  controlId="validationDrivingLicenseExpirationDate"
                >
                  <Form.Label>Data de Validade da CNH</Form.Label>
                  <Form.Control
                    required
                    type="date"
                    value={
                      drivingLicenseExpirationDate === ""
                        ? moment(
                            driverLoaded.drivingLicenseExpirationDate
                          ).format("YYYY-MM-DD")
                        : drivingLicenseExpirationDate
                    }
                    onChange={(e) =>
                      setDrivingLicenseExpirationDate(e.target.value)
                    }
                  />
                </Form.Group>
              </Row>
              <Row className="mb-1">
                <Form.Group as={Col} md="12" controlId="validationEmail">
                  <Form.Label>Email</Form.Label>
                  <Form.Control
                    required
                    type="email"
                    placeholder="Email"
                    value={email === "" ? driverLoaded?.email : email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </Form.Group>
              </Row>
              <Row className="mb-1">
                <Form.Group as={Col} md="12" controlId="validationCity">
                  <Form.Label>Cidade</Form.Label>
                  <Form.Control
                    required
                    type="text"
                    placeholder="Cidade"
                    value={city === "" ? driverLoaded?.city : city}
                    onChange={(e) => setCity(e.target.value)}
                  />
                </Form.Group>
              </Row>
              <S.RowButtons>
                <Button variant="warning" type="submit" size="lg">
                  Editar Motorista
                </Button>
                <Button
                  variant="danger"
                  size="lg"
                  onClick={() => navigate("/")}
                >
                  Cancelar
                </Button>
              </S.RowButtons>
            </Form>
          </S.FormBase>
        </Container>
      )}
    </React.Fragment>
  );
}
