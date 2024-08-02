# README - Orders Management Application

## Description

The **Orders Management Application** is a desktop application developed using Windows Forms (WinForms) for managing orders and products. This application allows you to load, view, modify, and save order and product data from an XML file. It is designed as a technical test to demonstrate skills in WinForms development.

## Features

1. **Load Orders**: Load and view a list of orders from an XML file.
2. **View Order Details**: Displays the details of the selected order.   
3. **View Products of the Order**: Displays products associated with the selected order with details. 
4. **Modify Products**:
   - Edit product prices.
   - Add new products (always has an empty row for new data).
   - Modify quantity and comment for products.
   - If the price is edited, providing a comment is mandatory. If a comment is not provided, the price will revert to its previous value, and the comment cell will be forced to edit.
5. **Save Changes**: Save all modifications made to the XML file.
6. **Search Orders**: Search for orders by order number or customer name.
7. **Navigation**: Navigate between orders and products using interface buttons.

## Installation

1. Download the executable from the following link:

   [Download Orders Management Application](https://drive.google.com/file/d/1otdlp4YyCSFptDEOE7-tqmwJxF4XD8dO/view?usp=sharing)
   - A sample XML file is included in the root directory of the executable for testing purposes. It provides a basic structure for how the data should be formatted.

2. Run the downloaded file to start the application.

## Usage

1. **Load XML File**: Click the "Browse" button to select an XML file containing the order data.    
2. **Search Orders**: Enter a search term in the search box and click the "Search" button to filter the orders.
3. **View and Edit Products**:
   - Select an order in the orders table.
   - The products associated with the order will be displayed in the products table.
   - Edit prices and quantities as needed. Make sure to provide a comment if the price is modified.
4. **Save Changes**: Click the "Save" button to save changes to the XML file.
5. **Navigate**: Use the "Next" button to select the next product in the products table.

## XML Format

The XML file should follow the format below to be compatible with the application. Here's an example of how the orders and products should be structured:

```xml
<Orders>
  <Order>
    <OrderNumber>123</OrderNumber>
    <Date>2023-07-31T00:00:00</Date>
    <ItemCount>2</ItemCount>
    <TotalPrice>100.00</TotalPrice>
    <CustomerName>Juan</CustomerName>
    <Products>
      <Product>
        <OrderNumber>123</OrderNumber>
        <ProductName>Product1</ProductName>
        <Price>50.003</Price>
        <Quantity>1</Quantity>
        <Comment>First comment</Comment>
      </Product>
      <Product>
        <OrderNumber>123</OrderNumber>
        <ProductName>Product23</ProductName>
        <Price>50.00</Price>
        <Quantity>1</Quantity>
        <Comment>Second comment</Comment>
      </Product>
      <Product>
        <OrderNumber>123</OrderNumber>
        <ProductName>sdfsdf</ProductName>
        <Price>774923</Price>
        <Quantity>2</Quantity>
        <Comment>sdfsadfasdfs</Comment>
      </Product>
    </Products>
  </Order>
</Orders>