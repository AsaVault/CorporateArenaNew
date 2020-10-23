import { ContactService } from './../../services/contact.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {
  contact: any = {};

  constructor(private service: ContactService) { }

  ngOnInit(): void {
  }

  onSubmit(): void{
      console.warn(this.contact);
      this.service.postContact(this.contact).subscribe(next => {
       console.warn('Message sent' + next);
       this.contact.userName = '';
       this.contact.email = '';
       this.contact.message = '';
     }, error => {
       console.warn('message failed to send');
     });
    // console.warn(this.contact);
  }
}
