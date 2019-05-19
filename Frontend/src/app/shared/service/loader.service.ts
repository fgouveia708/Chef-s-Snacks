import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable()
export class LoaderService {
  public showLoader: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  private loaderCounter: number = 0;

  constructor() {
  }


  public enable() {
    this.loaderCounter++;
    this.verifyLoader();
  }

  public disable() {
    this.loaderCounter--;
    this.verifyLoader();
  }


  public reset() {
    this.loaderCounter = 0;
    this.verifyLoader();
  }


  private verifyLoader() {
    const hasLoader = this.showLoader.getValue();

    if (!hasLoader && this.loaderCounter > 0) {
      this.showLoader.next(true);
    }
    else if (hasLoader && this.loaderCounter == 0) {
      this.showLoader.next(false);
    }
  }
}
