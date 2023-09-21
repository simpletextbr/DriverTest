import styled from "styled-components";

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  height: 100vh;
  margin-top: 20px;
  .logo {
    position: absolute;
    top: 0;
    left: 0;
  }
`;

export const Title = styled.div`
  font-size: calc(1em + 1vw);
  font-weight: bold;
  text-align: center;
  margin: 20px 0px;
`;

export const FormBase = styled.div`
  display: flex;
  flex-direction: column;
  width: 100%;
  max-width: 40%;
  height: fit-content;
  padding: 20px;
  border-radius: 10px;
  background-color: #f0f0f0;
`;

export const RowButtons = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  margin: 30px 0px;
`;
