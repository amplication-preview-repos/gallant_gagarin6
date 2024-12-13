import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { PayrollService } from "./payroll.service";
import { PayrollControllerBase } from "./base/payroll.controller.base";

@swagger.ApiTags("payrolls")
@common.Controller("payrolls")
export class PayrollController extends PayrollControllerBase {
  constructor(protected readonly service: PayrollService) {
    super(service);
  }
}
