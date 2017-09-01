package com.ankamagames.dofus.network.types.game.finishmoves
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class FinishMoveInformations implements INetworkType
   {
      
      public static const protocolId:uint = 506;
       
      
      public var finishMoveId:uint = 0;
      
      public var finishMoveState:Boolean = false;
      
      public function FinishMoveInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 506;
      }
      
      public function initFinishMoveInformations(param1:uint = 0, param2:Boolean = false) : FinishMoveInformations
      {
         this.finishMoveId = param1;
         this.finishMoveState = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.finishMoveId = 0;
         this.finishMoveState = false;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FinishMoveInformations(param1);
      }
      
      public function serializeAs_FinishMoveInformations(param1:ICustomDataOutput) : void
      {
         if(this.finishMoveId < 0)
         {
            throw new Error("Forbidden value (" + this.finishMoveId + ") on element finishMoveId.");
         }
         param1.writeInt(this.finishMoveId);
         param1.writeBoolean(this.finishMoveState);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FinishMoveInformations(param1);
      }
      
      public function deserializeAs_FinishMoveInformations(param1:ICustomDataInput) : void
      {
         this._finishMoveIdFunc(param1);
         this._finishMoveStateFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FinishMoveInformations(param1);
      }
      
      public function deserializeAsyncAs_FinishMoveInformations(param1:FuncTree) : void
      {
         param1.addChild(this._finishMoveIdFunc);
         param1.addChild(this._finishMoveStateFunc);
      }
      
      private function _finishMoveIdFunc(param1:ICustomDataInput) : void
      {
         this.finishMoveId = param1.readInt();
         if(this.finishMoveId < 0)
         {
            throw new Error("Forbidden value (" + this.finishMoveId + ") on element of FinishMoveInformations.finishMoveId.");
         }
      }
      
      private function _finishMoveStateFunc(param1:ICustomDataInput) : void
      {
         this.finishMoveState = param1.readBoolean();
      }
   }
}
