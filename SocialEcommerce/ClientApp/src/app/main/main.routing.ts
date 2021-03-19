import { Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";

export const MainRoutes: Routes = [
    {
        path: '',
        children: [
            {
                path: "home",
                component: HomeComponent
            }
        ]
    }
];
