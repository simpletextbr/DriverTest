import { Button, Modal } from "react-bootstrap";
import React from "react";

type DeleteModalProps = {
  id: string;
  show: boolean;
  handleClose: () => void;
  handleDelete: (id: string) => void;
};

function DeleteModal(proops: DeleteModalProps): React.JSX.Element {
  return (
    <div
      className="modal show"
      style={{ display: "block", position: "initial" }}
    >
      <Modal
        show={proops.show}
        onHide={proops.handleClose}
        aria-labelledby="contained-modal-title-vcenter"
        centered
      >
        <Modal.Header>
          <Modal.Title>Deletar Motorista</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p>Tem certeza que deseja deletar o motorista?</p>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={proops.handleClose}>
            Cancelar
          </Button>
          <Button
            variant="danger"
            onClick={() => proops.handleDelete(proops.id)}
          >
            Deletar
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}

export default DeleteModal;
