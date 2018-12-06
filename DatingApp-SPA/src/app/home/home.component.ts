import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
registerToggle = false;
values: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValues();
  }

  register() {
    this.registerToggle = true;
  }

  getValues() {
    this.http.get('http://192.168.1.20:5000/api/values').subscribe(response => {
      this.values = response;
      console.log(this.values);
    },
    error => {
      console.log(error);
    });
  }

  cancelRegisterMode(registerMoe: boolean) {
    this.registerToggle = registerMoe;
  }
}
