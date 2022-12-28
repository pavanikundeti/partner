import { TestBed } from '@angular/core/testing';
import { FetchDataComponent } from './weather.component';

describe('FetchDataComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        FetchDataComponent
      ],
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(FetchDataComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'Partner Portal - Weather'`, () => {
    const fixture = TestBed.createComponent(FetchDataComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('Partner Portal - Weather');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(FetchDataComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.content span')?.textContent).toContain('Partner Portal app is running!');
  });
});
