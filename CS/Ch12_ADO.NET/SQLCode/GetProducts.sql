SELECT P.ProductID as 'ID'
     , P.ProductName as 'Name'
     , C.CategoryName as 'Category'
  FROM Products P 
  JOIN Categories C on C.CategoryID = P.CategoryID


