import { CodingEvent } from './../../shared/coding-event.model';
import { CodingEventService } from './../../shared/coding-event.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-coding-events-form',
  templateUrl: './coding-events-form.component.html',
  styles: []
})
export class CodingEventsFormComponent implements OnInit {

  constructor(public service : CodingEventService) { }

  ngOnInit():void {
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new CodingEvent();
  }

  onSubmit(form: NgForm) {
    if(this.service.formData.eventId==0){
      this.insertRecord(form);
    }
    else{
      this.updateRecord(form);
    }
  }

  insertRecord(form: NgForm) {
    this.service.postCodingEvent().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => { console.log(err); }
    )
  }

  updateRecord(form: NgForm) {
    this.service.putCodingEvent().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }

}
