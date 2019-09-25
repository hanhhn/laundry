import { Directive, HostListener } from "@angular/core";
import { StepperSelectionEvent } from "@angular/cdk/stepper";
import { MatStepper } from "@angular/material/stepper";

@Directive({
  selector: "[appVerticalStepperScroller]"
})
export class VerticalStepperScrollerDirective {
  constructor(private stepper: MatStepper) {}

  @HostListener("selectionChange", ["$event"])
  selectionChanged(selection: StepperSelectionEvent) {
    const stepId = this.stepper._getStepLabelId(selection.selectedIndex);
    const stepElement = document.getElementById(stepId);
    if (stepElement) {
      stepElement.scrollIntoView({
        block: "start",
        inline: "nearest",
        behavior: "smooth"
      });
    }
  }
}
