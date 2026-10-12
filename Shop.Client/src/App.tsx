
import { useEffect, useState } from 'react';
import './App.css'
import type { Product } from './types/Product';
import { getProducts } from './services/productService';



function App() {

  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    getProducts()
    .then (data => setProducts(data))
    .catch (error => console.error(error));
  }, [])

  return (
    <main>
      <h1>Shop</h1>
      <p>Каталог товаров</p>

      {products.length === 0 ? (
    <p>Товаров пока нет</p>
  ) : (
    <div>
      {products.map(product => (
        <article key={product.id}>
          <h3>{product.name}</h3>
          <p>Цена: {product.price}</p>
          <p>В наличии: {product.stockQuantity}</p>
        </article>
      ))}
    </div>
  )}
    </main>
  )
}

export default App
