import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: [
  ]
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Output() cancelRegister = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  register(){
    console.log(this.model);
  }

  cancel(){
    this.cancelRegister.emit(false);
  }
}
