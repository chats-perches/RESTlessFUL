import { CodingEventService } from './../shared/coding-event.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-coding-events',
  templateUrl: './coding-events.component.html',
  styleUrls: ['./coding-events.component.css']
})
export class CodingEventsComponent implements OnInit {

  constructor(public service: CodingEventService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(selectedRecord) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(byebye) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteCodingEvent(byebye)
        .subscribe(res => {
          this.service.refreshList();
        },
        err => { console.log(err); })
    }
  }

}
