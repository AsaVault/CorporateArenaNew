import { QuestionService } from './../../services/question.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Question } from 'src/app/models';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {
  questions: Question[];
  content = '';
  selectedBrainTeaser: number;
  page: number;
  pageSize: number;
  questionId;
  view = 'answer';
  username = 'admin';
  selectedEntry: boolean;

  constructor(private service: QuestionService, private route: Router) { }

  ngOnInit(): void {
    this.page = 1;
    this.pageSize = 10;
    // tslint:disable-next-line: deprecation
    this.service.getAllQuestion(1, 10).subscribe((data) => {
      this.questions = data;
      // console.log(`Brain teasers are as follows: ${JSON.stringify(this.brainTeasers)}`);
      if (this.questions.length > 0) {
        this.selectedBrainTeaser = this.questions[0].id;
      }
    });
  }

  toggleView(view: string): void {
    this.view = view;
  }

  toggleSelected(selected: number = null): void {
    if (selected) {
      if (this.isSelected(selected)) {
        return;
      }

      this.selectedBrainTeaser = selected;
      console.log(selected);
      return;
    }
    this.selectedBrainTeaser = null;
  }

  isSelected(id: number): boolean {
    return id === this.selectedBrainTeaser;
  }

  getUrl(slug: string): string {
    return `/question/${slug}`;
  }

}
