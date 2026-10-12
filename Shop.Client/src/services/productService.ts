import type { Product } from "../types/Product";

export async function getProducts() : Promise<Product[]> {
    const response = await fetch("http://localhost:5138/api/products");
    if (!response.ok) {
        throw new Error("Failed to fetch products");
    }
    return response.json();
    
}