export type Product = {
  id: number,
  name: string,
  code: string,
  description?: string,
  categoryId: number,
  price: number,
  isActive: boolean,
  stockQuantity: number,
  imageUrl?: string;
}