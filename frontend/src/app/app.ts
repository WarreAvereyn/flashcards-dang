import { Component, OnInit } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  protected title = 'Flashcards';
  protected darkMode = false;

  ngOnInit() {
    this.darkMode = localStorage.getItem('darkMode') === 'true';
    this.applyDark();
  }

  protected toggleDark() {
    this.darkMode = !this.darkMode;
    localStorage.setItem('darkMode', String(this.darkMode));
    this.applyDark();
  }

  private applyDark() {
    document.documentElement.classList.toggle('dark', this.darkMode);
  }
}
