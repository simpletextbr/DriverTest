import styled from "styled-components";

export const ModalBody = styled.div`
  display: flex;
  flex-direction: column;
  width: 100%;
  height: fit-content;
  padding: 20px;
`;

export const ModalTitle = styled.div`
  font-size: calc(1em + 1vw);
  font-weight: bold;
  text-align: center;
  margin-top: -30px;
  margin-bottom: 10px;
`;

export const ModalCardContainer = styled.div`
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-gap: 20px;
  width: 100%;
  margin-bottom: 20px;
`;

export const ModalCard = styled.div`
  display: flex;
  flex-direction: column;
  width: 100%;
  height: fit-content;
  padding: 20px;
  border-radius: 10px;
  background-color: #0d6efd;
  color: white;
  text-align: center;
`;

export const ModalCardTitle = styled.div`
  font-size: calc(1em + 0.1vw);
  font-weight: bold;
  text-align: center;
  margin-bottom: 10px;
`;
