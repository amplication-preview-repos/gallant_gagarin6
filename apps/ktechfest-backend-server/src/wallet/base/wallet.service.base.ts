/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { PrismaService } from "../../prisma/prisma.service";

import {
  Prisma,
  Wallet as PrismaWallet,
  Transaction as PrismaTransaction,
  User as PrismaUser,
} from "@prisma/client";

export class WalletServiceBase {
  constructor(protected readonly prisma: PrismaService) {}

  async count(args: Omit<Prisma.WalletCountArgs, "select">): Promise<number> {
    return this.prisma.wallet.count(args);
  }

  async wallets(args: Prisma.WalletFindManyArgs): Promise<PrismaWallet[]> {
    return this.prisma.wallet.findMany(args);
  }
  async wallet(
    args: Prisma.WalletFindUniqueArgs
  ): Promise<PrismaWallet | null> {
    return this.prisma.wallet.findUnique(args);
  }
  async createWallet(args: Prisma.WalletCreateArgs): Promise<PrismaWallet> {
    return this.prisma.wallet.create(args);
  }
  async updateWallet(args: Prisma.WalletUpdateArgs): Promise<PrismaWallet> {
    return this.prisma.wallet.update(args);
  }
  async deleteWallet(args: Prisma.WalletDeleteArgs): Promise<PrismaWallet> {
    return this.prisma.wallet.delete(args);
  }

  async findTransactions(
    parentId: string,
    args: Prisma.TransactionFindManyArgs
  ): Promise<PrismaTransaction[]> {
    return this.prisma.wallet
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .transactions(args);
  }

  async findUsers(
    parentId: string,
    args: Prisma.UserFindManyArgs
  ): Promise<PrismaUser[]> {
    return this.prisma.wallet
      .findUniqueOrThrow({
        where: { id: parentId },
      })
      .users(args);
  }
}
