import { Component } from '@angular/core';
import { Hero } from './hero';

@Component({
    selector: 'hero-form',
    templateUrl: './hero-form.html'
})

export class HeroFormComponent {
    powers = ['Smart', 'Flexible', 'Hot', 'Fast'];
    model = new Hero(1, 'Dr. Smart', this.powers[0], 'Hans Zimmer');
    submitted = false;
    onSubmit() {this.submitted = true;}
    newHero() {this.model = new Hero(2, "", "", "")}
    get diagnostic() { return JSON.stringify(this.model); }

}