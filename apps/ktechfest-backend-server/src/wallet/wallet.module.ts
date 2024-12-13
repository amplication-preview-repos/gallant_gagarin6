import { Module } from "@nestjs/common";
import { WalletModuleBase } from "./base/wallet.module.base";
import { WalletService } from "./wallet.service";
import { WalletController } from "./wallet.controller";

@Module({
  imports: [WalletModuleBase],
  controllers: [WalletController],
  providers: [WalletService],
  exports: [WalletService],
})
export class WalletModule {}
