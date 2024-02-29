import {Book} from "./models";
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class State {
  books: Book[] = [];
}
