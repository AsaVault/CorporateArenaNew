import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Question } from 'src/app/models';
import { QuestionService } from 'src/app/services/question.service';

@Component({
  selector: 'app-question-create',
  templateUrl: './question-create.component.html',
  styleUrls: ['./question-create.component.scss']
})
export class QuestionCreateComponent implements OnInit {
  question: Question;
  content = '';
  constructor(private service: QuestionService, private route: Router) { }

  ngOnInit(): void {
  }

  submitQuestion(): void {
    if (this.content.length === 0) {
      return;
    }
    this.question = {
      isDeleted: false,
      content: this.content,
      isDisplayed: true,
      id: 0,
      questionAnswers: null,
      questionOptions: null,
      createdOn: new Date(),
      updatedOn: new Date(),
    };
    this.service
      .postQuestion(this.question)
      .subscribe((response) => {
        this.content = '';
        this.route.navigate(['/question']);
      });
  }
}
