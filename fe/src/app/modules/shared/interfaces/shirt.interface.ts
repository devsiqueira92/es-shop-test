import { ShirtDetais } from './shirt-details.interface';

export interface Shirt {
  id: string;
  itemName: string;

  details: ShirtDetais;
}
