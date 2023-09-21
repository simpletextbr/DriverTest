import React, { useState } from "react";
import * as S from "./styles";
import { Form, Button, Row, Col } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { CreateDriverInput } from "../../../core/api/DriverManagement/interfaces/CreateDriver.interface";
import { CreateDriver } from "../../../core/api/DriverManagement/DriverManagment";

export default function RegisterPage(): React.JSX.Element {
  const [validated, setValidated] = useState(false);
  const [name, setName] = useState<string>("");
  const [birthDate, setBirthDate] = useState<string>();
  const [drivingLicenseNumber, setDrivingLicenseNumber] = useState<string>("");
  const [drivingLicenseExpirationDate, setDrivingLicenseExpirationDate] =
    useState<string>();
  const [email, setEmail] = useState<string>("");
  const [city, setCity] = useState<string>("");

  const navigate = useNavigate();

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

        const driver: CreateDriverInput = {
          name: name,
          dateOfBirth: handleDate(birthDate!),
          drivingLicenseNumber: drivingLicenseNumber,
          drivingLicenseExpirationDate: handleDate(
            drivingLicenseExpirationDate!
          ),
          email: email,
          city: city,
        };

        await CreateDriver(driver);
        toast.success(`Motorista ${name} cadastrado com sucesso`);
        navigate("/");
      } catch (error) {
        toast.error("Não foi possível cadastrar o motorista");
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

  return (
    <React.Fragment>
      <S.Container>
        <S.Title>Cadastrar novos motoristas</S.Title>
        <S.FormBase>
          <Form noValidate validated={validated} onSubmit={handleSubmit}>
            <Row className="mb-1">
              <Form.Group as={Col} md="12" controlId="validationName">
                <Form.Label>Nome</Form.Label>
                <Form.Control
                  required
                  type="text"
                  placeholder="Nome"
                  value={name}
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
                  value={birthDate}
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
                  value={drivingLicenseNumber}
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
                  value={drivingLicenseExpirationDate}
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
                  value={email}
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
                  value={city}
                  onChange={(e) => setCity(e.target.value)}
                />
              </Form.Group>
            </Row>
            <S.RowButtons>
              <Button variant="success" type="submit" size="lg">
                Novo Motorista
              </Button>
              <Button variant="danger" size="lg" onClick={() => navigate("/")}>
                Cancelar
              </Button>
            </S.RowButtons>
          </Form>
        </S.FormBase>
      </S.Container>
    </React.Fragment>
  );
}
