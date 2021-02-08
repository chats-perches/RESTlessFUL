import { CodingEvent } from './coding-event.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class CodingEventService {

  formData : CodingEvent = new CodingEvent();
  readonly baseURL = 'http://localhost:62107/api/events';
  list : CodingEvent[];

  constructor(private http: HttpClient) { }

  postCodingEvent(){
    return this.http.post(this.baseURL, this.formData);
  }

  putCodingEvent(){
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }

  deleteCodingEvent(eventId: number){
    return this.http.delete(`${this.baseURL}/${eventId}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
      .toPromise()
      .then(resp => this.list = resp as CodingEvent[]);
  }

}
