
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CadastroUsuarioComponent } from "./create/cadastro-usuario/cadastro-usuario.component";
import { ProfileComponent } from "./profile/profile.component";

const routes: Routes = [
    {
        path: 'novo', component: CadastroUsuarioComponent 
    },
    {
        path: 'profile', component: ProfileComponent 
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ControleUsuarioRoutingModule { }
