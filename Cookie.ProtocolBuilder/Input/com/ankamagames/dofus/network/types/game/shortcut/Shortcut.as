package com.ankamagames.dofus.network.types.game.shortcut
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class Shortcut implements INetworkType
   {
      
      public static const protocolId:uint = 369;
       
      
      public var slot:uint = 0;
      
      public function Shortcut()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 369;
      }
      
      public function initShortcut(param1:uint = 0) : Shortcut
      {
         this.slot = param1;
         return this;
      }
      
      public function reset() : void
      {
         this.slot = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_Shortcut(param1);
      }
      
      public function serializeAs_Shortcut(param1:ICustomDataOutput) : void
      {
         if(this.slot < 0 || this.slot > 99)
         {
            throw new Error("Forbidden value (" + this.slot + ") on element slot.");
         }
         param1.writeByte(this.slot);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_Shortcut(param1);
      }
      
      public function deserializeAs_Shortcut(param1:ICustomDataInput) : void
      {
         this._slotFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_Shortcut(param1);
      }
      
      public function deserializeAsyncAs_Shortcut(param1:FuncTree) : void
      {
         param1.addChild(this._slotFunc);
      }
      
      private function _slotFunc(param1:ICustomDataInput) : void
      {
         this.slot = param1.readByte();
         if(this.slot < 0 || this.slot > 99)
         {
            throw new Error("Forbidden value (" + this.slot + ") on element of Shortcut.slot.");
         }
      }
   }
}
