import styled, { createGlobalStyle } from "styled-components";

const GlobalStyles = createGlobalStyle`
 * {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    text-decoration: none;
  }

  html, body{
  min-height: 100vh;
  }

  #root{
  min-height: 100vh;
  }

  body {
    font-family:  'Roboto', sans-serif;
  }
`;

export const buttonDefault = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  padding: 4px;
  filter: drop-shadow(0px, 4px 4px rgba(0, 0, 0, 0.25));
  height: 40px;
  border-radius: 8px;
  font-size: 0.9rem;
  font-weight: 700;
  cursor: pointer;
  animation: slideup 1s forwards;

  svg {
    margin-left: 6px;
    transition: all ease 0.2s;
  }

  :hover {
    svg {
      margin-left: 20px;
    }
  }

  @keyframes slideup {
    from {
      margin-top: 30px;
      opacity: 0;
    }
    to {
      margin-top: 0px;
      opacity: 1;
    }
  }
`;

export const title = styled.p`
  font-size: 14px;
  margin-left: 20px;
  font-weight: 700;
  color: #1787ee;
`;

export default GlobalStyles;
