import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PictureofthedayComponent } from './pictureoftheday.component';

describe('PictureofthedayComponent', () => {
  let component: PictureofthedayComponent;
  let fixture: ComponentFixture<PictureofthedayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PictureofthedayComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PictureofthedayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
