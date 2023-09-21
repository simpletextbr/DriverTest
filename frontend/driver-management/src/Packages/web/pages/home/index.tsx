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

export default function HomePage(): React.JSX.Element {
  const [drivers, setDrivers] = useState<Driver[]>();
  const [refresh, setRefresh] = useState<boolean>(false);
  const [show, setShow] = useState<boolean>(false);
  const navigate = useNavigate();

  async function handleDelete(id: string) {
    try {
      await DeleteDriver({ id });
      setRefresh(true);
      setShow(false);
      toast.success("Motorista deletado com sucesso");
    } catch (error) {
      toast.error("Não foi possível deletar o motorista");
    }
  }

  const handleClose = () => setShow(false);

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
      <S.Title>Motoritas Cadastrados</S.Title>
      {!drivers ? (
        <S.Container>
          <Triangle
            height="80"
            width="80"
            color="#1c02af"
            ariaLabel="triangle-loading"
            wrapperStyle={{}}
            visible={true}
          />
        </S.Container>
      ) : (
        <S.Container>
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
                        onClick={() => navigate(`/detailed/${driver.id}`)}
                      >
                        Detalhes
                      </Button>
                      <Button
                        variant="warning"
                        onClick={() => navigate(`/update/${driver.id}`)}
                      >
                        Editar
                      </Button>
                      <Button variant="danger" onClick={() => setShow(true)}>
                        Deletar
                      </Button>
                    </Stack>
                  </Card.Footer>
                  <DeleteModal
                    id={driver.id.toString()}
                    handleDelete={handleDelete}
                    show={show}
                    handleClose={handleClose}
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
        </S.Container>
      )}
    </React.Fragment>
  );
}
