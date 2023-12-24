import React from "react";
import { Routes, Route } from "react-router-dom";
import Navbar from "./components/navbar/Navbar";
import Home from "./pages/home/Home.page";
import Products from "./pages/products/Products.page";
import AddProduct from "./pages/add-product/AddProduct.page";
import EditProduct from "./pages/edit-product/EditPRoduct.page";
import DeleteProduct from "./pages/delete-product/DeleteProduct";

const App: React.FC = () => {
  return (
    <div>
      {/* Navbar */}
      <Navbar />

      {/* Wrapper */}
      <div className="wrapper">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/products">
            <Route index element={<Products></Products>} />
            <Route path="add" element={<AddProduct />}></Route>
            <Route path="edit/:id" element={<EditProduct />}></Route>
            <Route path="delete/:id" element={<DeleteProduct />}></Route>
          </Route>
        </Routes>
      </div>
    </div>
  );
};

export default App;
