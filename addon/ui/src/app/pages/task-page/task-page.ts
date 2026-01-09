import { Component, OnInit } from '@angular/core';
import { ITask } from '../../models/task';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-task-page',
  imports: [TableModule, CommonModule, ButtonModule],
  templateUrl: './task-page.html',
  styleUrl: './task-page.scss',
})
export class TaskPage implements OnInit {

  public taskList: ITask[] = [];

  constructor(private http: HttpClient) {
    // this.getTasks().then(() => {
    //   console.log('Tasks loaded');
    // });   
  }

  async ngOnInit(): Promise<void> {
    await this.getTasks();
  }

  public async getTasks() {
    // const basePath = window.location.pathname;

    // console.log(basePath);

    fetch(`${environment.apiUrl}/Task`)
      .then(response => response.json())
      .then(data => {
        this.taskList = data;
        console.log(this.taskList);
      });
  }
}
