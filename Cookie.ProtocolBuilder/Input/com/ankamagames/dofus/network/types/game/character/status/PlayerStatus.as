package com.ankamagames.dofus.network.types.game.character.status
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PlayerStatus implements INetworkType
   {
      
      public static const protocolId:uint = 415;
       
      
      public var statusId:uint = 1;
      
      public function PlayerStatus()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 415;
      }
      
      public function initPlayerStatus(param1:uint = 1) : PlayerStatus
      {
         this.statusId = param1;
         return this;
      }
      
      public function reset() : void
      {
         this.statusId = 1;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PlayerStatus(param1);
      }
      
      public function serializeAs_PlayerStatus(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.statusId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PlayerStatus(param1);
      }
      
      public function deserializeAs_PlayerStatus(param1:ICustomDataInput) : void
      {
         this._statusIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PlayerStatus(param1);
      }
      
      public function deserializeAsyncAs_PlayerStatus(param1:FuncTree) : void
      {
         param1.addChild(this._statusIdFunc);
      }
      
      private function _statusIdFunc(param1:ICustomDataInput) : void
      {
         this.statusId = param1.readByte();
         if(this.statusId < 0)
         {
            throw new Error("Forbidden value (" + this.statusId + ") on element of PlayerStatus.statusId.");
         }
      }
   }
}
