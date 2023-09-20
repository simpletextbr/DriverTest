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
  font-size: 2rem;
  font-weight: bold;
  text-align: center;
  margin: 20px 0px;
`;

export const CardsContainer = styled.div`
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  grid-gap: 20px;
  width: 100%;
  max-width: 1000px;
  margin-bottom: 20px;
`;
