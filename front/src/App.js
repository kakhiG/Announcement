import React, { Component } from "react";
import { Link, Switch, Route } from 'react-router-dom'
import AddItem from "./components/AddItem";
import Item from "./components/Item";
import ItemList from "./components/ItemList";

function App() {
  return (
    <div>
      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <a href="/items" className="navbar-brand">
          Announcement
        </a>
        <div className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to={"/items"} className="nav-link">
              Items
            </Link>
          </li>
          <li className="nav-item">
            <Link to={"/add"} className="nav-link">
              Add
            </Link>
          </li>
        </div>
      </nav>

      <div className="container mt-3">
        <Switch>
          <Route exact path={["/", "/items"]} component={ItemList} />
          <Route exact path="/add" component={AddItem} />
          <Route path="/items/:id" component={Item} />
        </Switch>
      </div>
    </div>
  );
}

export default App;