import React, { useState } from "react";
import AnnouncementService from "../services/AnnouncementService";

const AddItem = props => {
  const [itemTitle, setItemTitle] = useState('');
  const [itemDescription, setItemDescription] = useState('');
  const [itemMobileNumber, setItemMobileNumber] = useState('');
  const [itemImageData, setItemImageData] = useState([]);

  let fileReader;

  const handleFileRead = (e) => {
    const content = Array.from(new Int8Array(fileReader.result)); 
    setItemImageData(content);
  }

  const readFileContents = (file)=> {
      fileReader = new FileReader();
      fileReader.onload = handleFileRead;
      fileReader.readAsArrayBuffer(file);
  }

  const saveItem = () => {
    var data = {
      title: itemTitle,
      description: itemDescription,
      mobileNumber: itemMobileNumber,
      imageData: itemImageData
    };
debugger;
    AnnouncementService.create(data)
      .then(response => {
        console.log(response.data);
        props.history.push("/items");
      })
      .catch(e => {
        console.log(e);
      });
  };

  return (
    <div className="submit-form">
        <div>
          <div className="form-group">
            <label htmlFor="title">Title</label>
            <input
              type="text"
              className="form-control"
              id="title"
              required
              value={itemTitle}
              onChange={(e)=>setItemTitle(e.target.value)}
              name="title"
            />
          </div>

          <div className="form-group">
            <label htmlFor="description">Description</label>
            <input
              type="text"
              className="form-control"
              id="description"
              required
              value={itemDescription}
              onChange={(e)=>setItemDescription(e.target.value)}
              name="description"
            />
          </div>

          <div className="form-group">
            <label htmlFor="mobileNumber">Mobile Number</label>
            <input
              type="text"
              className="form-control"
              id="mobileNumber"
              required
              value={itemMobileNumber}
              onChange={(e)=>setItemMobileNumber(e.target.value)}
              name="mobileNumber"
            />
          </div>

          <div className="form-group">
            <label htmlFor="image">Image</label>
            <input
              type="file"
              className="form-control"
              id="image"
              required
              onChange={(e)=>readFileContents(e.target.files[0])}
              name="mobileNumber"
            />
          </div>

          <button onClick={saveItem} className="btn btn-success">
            Submit
          </button>
        </div>
    </div>
  );
};

export default AddItem;