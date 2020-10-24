import { QuestionService } from './../../services/question.service';
import { Component, OnInit } from '@angular/core';
import { Question, QuestionOptions } from 'src/app/models';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-question-option',
  templateUrl: './question-option.component.html',
  styleUrls: ['./question-option.component.scss']
})
export class QuestionOptionComponent implements OnInit {
  question: Question;
  questionId: number;
  content = '';
  optionLetter = '';
  isCorrect = false;
  selectedQuestion: number;
  view = '';
  isSubmitted: boolean;
  isTrue = true;
  isFalse = false;
  selectedEntry: boolean;

  constructor(private service: QuestionService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.service
      .getQuestion(this.route.snapshot.paramMap.get('id'))
      .subscribe((question) => {
        this.question = question;
        this.questionId = question.id;
      });
  }

  submitOption(): void {
    if (this.content.length === 0 || this.optionLetter.length === 0) {
      return;
    }

    const option: QuestionOptions = {
      id: 0,
      optionLetter: this.optionLetter,
      content: this.content,
      questionId: this.questionId,
      isCorrect: this.selectedEntry,
      isDisplayed: true,
      isDeleted: false,
      createdOn: new Date(),
      updatedOn: new Date()
    };

    this.service
      .postQuestionOptions(this.questionId, option)
      .subscribe((newOption) => {
        // this.blog.comments = [newComment, ...this.blog.comments];
        this.content = '';
        this.optionLetter = '';
        this.selectedEntry = true;
        this.isSubmitted = true;
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

      this.selectedQuestion = selected;
      console.log(selected);
      return;
    }
    this.selectedQuestion = null;
  }

  isSelected(id: number): boolean {
    return id === this.selectedQuestion;
  }

  onSelectionChange(entry): void {
    // console.log(`radio button was clicked ${entry}`);
    this.selectedEntry = entry;
  }
}
