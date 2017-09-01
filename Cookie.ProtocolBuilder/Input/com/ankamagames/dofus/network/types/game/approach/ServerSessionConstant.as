package com.ankamagames.dofus.network.types.game.approach
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ServerSessionConstant implements INetworkType
   {
      
      public static const protocolId:uint = 430;
       
      
      public var id:uint = 0;
      
      public function ServerSessionConstant()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 430;
      }
      
      public function initServerSessionConstant(param1:uint = 0) : ServerSessionConstant
      {
         this.id = param1;
         return this;
      }
      
      public function reset() : void
      {
         this.id = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ServerSessionConstant(param1);
      }
      
      public function serializeAs_ServerSessionConstant(param1:ICustomDataOutput) : void
      {
         if(this.id < 0)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeVarShort(this.id);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ServerSessionConstant(param1);
      }
      
      public function deserializeAs_ServerSessionConstant(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ServerSessionConstant(param1);
      }
      
      public function deserializeAsyncAs_ServerSessionConstant(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readVarUhShort();
         if(this.id < 0)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of ServerSessionConstant.id.");
         }
      }
   }
}
