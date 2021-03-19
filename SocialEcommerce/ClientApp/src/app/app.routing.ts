import { Routes } from "@angular/router";

export const AppRoutes: Routes = [
    {
        path: '',
        children: [
            {
                path: '',
                redirectTo: '/main/home',
                pathMatch: 'full'
              },
            {
                
                path: 'main',
                loadChildren: () => import('./main/main.module').then(m => m.MainModule)
            },
            {   
                path: 'auth',
                loadChildren: () => import('./Authentication/authentication.module').then(m => m.AuthenticationModule)
            }
        ]
    }
];