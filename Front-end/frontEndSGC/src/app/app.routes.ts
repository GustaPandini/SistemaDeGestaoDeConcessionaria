import { Routes } from '@angular/router';
import { Home } from './components/home/home';
import { Login } from './components/login/login';
import { HomeAdmin } from './components/home-admin/home-admin';

export const routes: Routes = [
{
    path: "",
    component: Home
},
{
    path: "login",
    component: Login
},
{ 
    path: 'home-admin', 
    component: HomeAdmin 
}
];
