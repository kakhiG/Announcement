import React, { useState, useEffect } from "react";
//import AnnouncementService from '../services/AnnouncementService'
import axios from 'axios';

const ItemList = (props) => {
    const [items, setItems] = useState([]);
    const [searchTitle, setSearchTitle] = useState("");
    
    //const itemsRef = useRef();

    //itemsRef.current = items;

    // const onChangeSearchTitle = (e) => {
    //     const searchTitle = e.target.value;
    //     setSearchTsearchTitletle(searchTitle);
    // };
    
      
    const retrieveItems = () => {
       var url = "Announcements";
       if (searchTitle.length > 0) {
         url = "Announcements/search/" + searchTitle;
        }
        axios.get("https://localhost:44350/api/" + url)
        .then((response) => {
         setItems(response.data);
            })
            .catch((e) => {
                console.error(e);
           });
    };

    // const findByItem = () => {
    //     AnnouncementService.findByTitle(searchTitle)
    //         .then((response) => {
    //             setTutorials(response.data);
    //         })
    //         .catch((e) => {
    //             console.error(e);
    //         });
    // };

    // const openItem = (rowIndex) => {
    //     const id = tutorialsRef.current[rowIndex].id;

    //     props.history.push("/items/" + id);
    // };

    

    // const deleteItem = (rowIndex) => {
    // const id = itemssRef.current[rowIndex].id;

    //    AnnouncementService.remove(id)
    //        .then((response) => {
     //         props.history.push("/items");

     //           let newItems = [...itemsRef.current];
      //           newItems.splice(rowIndex, 1);

       //        setItems(newItems);
      //       })
       //      .catch((e) => {
      //          console.log(e);
      //      });
  //   };

    useEffect(() => {
        retrieveItems();
    }, [searchTitle]);

    return (
        <div className="form-inline">
            <div className="form-group mx-sm-3 mb-2">
                <input type="text" className="form-control" placeholder="Search by title" onChange={(e) => setSearchTitle(e.target.value)} />
            </div>
            <table className="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Photo</th>
                        <th>Title</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map((item) =>
                        <tr key={item.id}>
                            <td>{item.id}</td>
                            <td><img src="https://placehold.it/500x5400" /></td>
                            <td>{item.title}</td>
                            <td>
                                <div className="btn-group" role="group">
                                    <button type="button" className="btn btn-secondary">Edit</button>
                                    <button type="button" className="btn btn-secondary">Delete</button>
                                </div>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
};

export default ItemList;

