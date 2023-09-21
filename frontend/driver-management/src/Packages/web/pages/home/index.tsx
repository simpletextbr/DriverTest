import React, { useEffect, useState } from "react";
import {
  DeleteDriver,
  GetAllDrivers,
} from "../../../core/api/DriverManagement/DriverManagment";
import { Driver } from "../../../core/api/types";
import { Triangle } from "react-loader-spinner";
import { toast } from "react-toastify";
import * as S from "./styles";
import { Alert, Button, Card, Stack } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import DeleteModal from "../../components/Modals/DeleteModal";
import DetailModal from "../../components/Modals/DetailedModal";
import { Container, Title } from "../../styles/globalStyles";

export default function HomePage(): React.JSX.Element {
  const [drivers, setDrivers] = useState<Driver[]>();
  const [refresh, setRefresh] = useState<boolean>(false);
  const [showDeleteModal, setShowDeleteModal] = useState<boolean>(false);
  const [showDetailModal, setShowDetailModal] = useState<boolean>(false);
  const navigate = useNavigate();

  async function handleDelete(id: string) {
    try {
      await DeleteDriver({ id });
      setRefresh(true);
      setShowDeleteModal(false);
      toast.success("Motorista deletado com sucesso");
    } catch (error) {
      toast.error("Não foi possível deletar o motorista");
    }
  }

  const handleCloseDeleteModal = () => setShowDeleteModal(false);
  const handleCloseDetailModal = () => setShowDetailModal(false);

  useEffect(() => {
    const loadData = async () => {
      try {
        const result = await GetAllDrivers();

        setDrivers(result.items);
      } catch (error) {
        toast.error("Não foi possível carregar os motoristas");
        setDrivers([]);
      }
    };

    if (refresh) setRefresh(false);

    loadData();
  }, [refresh]);

  return (
    <React.Fragment>
      <Title>Motoritas Cadastrados</Title>
      {!drivers ? (
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
          {drivers.length === 0 ? (
            <Alert key="warning" variant="warning">
              Nenhum motorista cadastrado
            </Alert>
          ) : (
            <S.CardsContainer>
              {drivers.map((driver: Driver) => (
                <Card key={driver.id}>
                  <Card.Header>{driver.name}</Card.Header>
                  <Card.Body>
                    <Card.Title>Contato</Card.Title>
                    <Card.Text>{driver.email}</Card.Text>
                    <Card.Text>{driver.city}</Card.Text>
                  </Card.Body>
                  <Card.Footer>
                    <Stack direction="horizontal" gap={3}>
                      <Button
                        variant="primary"
                        onClick={() => setShowDetailModal(true)}
                      >
                        Detalhes
                      </Button>
                      <Button
                        variant="warning"
                        onClick={() => navigate(`/update/${driver.id}`)}
                      >
                        Editar
                      </Button>
                      <Button
                        variant="danger"
                        onClick={() => setShowDeleteModal(true)}
                      >
                        Deletar
                      </Button>
                    </Stack>
                  </Card.Footer>
                  <DeleteModal
                    id={driver.id.toString()}
                    handleDelete={handleDelete}
                    show={showDeleteModal}
                    handleClose={handleCloseDeleteModal}
                  />
                  <DetailModal
                    id={driver.id.toString()}
                    show={showDetailModal}
                    handleClose={handleCloseDetailModal}
                  />
                </Card>
              ))}
            </S.CardsContainer>
          )}
          <Button
            variant="success"
            size="lg"
            onClick={() => navigate(`/register`)}
          >
            Cadastrar Novo Motorista
          </Button>
        </Container>
      )}
    </React.Fragment>
  );
}
