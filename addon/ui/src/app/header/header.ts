import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Menubar } from 'primeng/menubar';

@Component({
  selector: 'app-header',
  imports: [Menubar],
  templateUrl: './header.html',
  styleUrl: './header.scss',
})
export class Header implements OnInit {

  public items: MenuItem[] = [];

  ngOnInit() {
    this.items = [
      {
        label: 'Home',
        icon: 'pi pi-home'
      },
      {
        label: 'Tasks',
        icon: 'pi pi-search',
        items: [
          {
            label: 'To Do',
            icon: 'pi pi-hammer',
            routerLink: '/tasks'
          },
          {
            label: 'To Buy',
            icon: 'pi pi-cart-plus'
          }
        ]
      },
      {
        label: 'Expenses',
        icon: 'pi pi-euro'
      },
      {
        label: 'Administration',
        icon: 'pi pi-cog'
      }
    ]
  }

}
