import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { TransactionService } from "./transaction.service";
import { TransactionControllerBase } from "./base/transaction.controller.base";

@swagger.ApiTags("transactions")
@common.Controller("transactions")
export class TransactionController extends TransactionControllerBase {
  constructor(protected readonly service: TransactionService) {
    super(service);
  }
}
