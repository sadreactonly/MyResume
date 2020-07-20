import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.min.css';
import React,{useState} from 'react';

function ContactFormModal(props) {
    return (
      <Modal
        {...props}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
      >
        <Modal.Header closeButton>
          <Modal.Title id="contained-modal-title-vcenter">
            Contact me
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>

        <form className="contact-form">
      <input type="hidden" name="contact_number" />
      <label>Name</label>
      <input type="text" name="from_name" />
      <label>Email</label>
      <input type="email" name="from_email" />
      <label>Subject</label>
      <input type="text" name="subject" />
      <label>Message</label>
      <textarea name="html_message" />
      <input type="submit" value="Send" />
    </form>

        </Modal.Body>
        <Modal.Footer>
          <Button onClick={props.onHide}>Close</Button>
        </Modal.Footer>
      </Modal>
    );
  }
  function ContactForm() {
    const [modalShow, setModalShow] = useState(false);
  
    return (
      <>
        <Button variant="secondary" onClick={() => setModalShow(true)}>
          Contact me
        </Button>

        <ContactFormModal show={modalShow} onHide={() => setModalShow(false)} />
      </>
    );
  }
  
  export default ContactForm;