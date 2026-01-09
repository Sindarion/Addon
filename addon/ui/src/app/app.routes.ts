import { Routes } from '@angular/router';
import { TaskPage } from './pages/task-page/task-page';

export const routes: Routes = [
    { path: 'tasks', component: TaskPage },
    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
];
