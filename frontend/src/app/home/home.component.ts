import {Component, inject, OnInit} from '@angular/core';
import {State} from "../../state";
import {BookService} from "../book.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent  implements OnInit {

  bookService = inject(BookService)
  constructor(public state: State) { }

  ngOnInit() {
    this.bookService.fetchBookFeed()
  }

  isAdmin() {

  }
}
