
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./home.component";
import { ControleUsuarioModule } from "./controle-usuario/controle-usuario.module";

const routes:Routes = [
    {
        path: '',
        component: HomeComponent, //Master
        children:[
            { path: '', redirectTo: 'charts'},
            { 
                path: 'controleusuario', 
                loadChildren: './controle-usuario/controle-usuario.module#ControleUsuarioModule'
            },
            {
                path: 'contasapagar',
                loadChildren: './contas-pagar/contas-pagar.module#ContasPagarModule'
            },
            { path: 'charts', loadChildren: './charts/charts.module#ChartsModule' }    
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HomeRoutingModule{

}