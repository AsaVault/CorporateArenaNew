import QuestionAnswers from './QuestionAnswers';
import QuestionOptions from './QuestionOptions';

class Question {
id: number;
content: string;
questionOptions: QuestionOptions[];
questionAnswers: QuestionAnswers[];
isDisplayed: boolean;
isDeleted: boolean;
createdOn: Date;
updatedOn: Date;
}

export default Question;
