package com.ankamagames.dofus.network.types.game.shortcut
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class ShortcutEmote extends Shortcut implements INetworkType
   {
      
      public static const protocolId:uint = 389;
       
      
      public var emoteId:uint = 0;
      
      public function ShortcutEmote()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 389;
      }
      
      public function initShortcutEmote(param1:uint = 0, param2:uint = 0) : ShortcutEmote
      {
         super.initShortcut(param1);
         this.emoteId = param2;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.emoteId = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ShortcutEmote(param1);
      }
      
      public function serializeAs_ShortcutEmote(param1:ICustomDataOutput) : void
      {
         super.serializeAs_Shortcut(param1);
         if(this.emoteId < 0 || this.emoteId > 255)
         {
            throw new Error("Forbidden value (" + this.emoteId + ") on element emoteId.");
         }
         param1.writeByte(this.emoteId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ShortcutEmote(param1);
      }
      
      public function deserializeAs_ShortcutEmote(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._emoteIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ShortcutEmote(param1);
      }
      
      public function deserializeAsyncAs_ShortcutEmote(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._emoteIdFunc);
      }
      
      private function _emoteIdFunc(param1:ICustomDataInput) : void
      {
         this.emoteId = param1.readUnsignedByte();
         if(this.emoteId < 0 || this.emoteId > 255)
         {
            throw new Error("Forbidden value (" + this.emoteId + ") on element of ShortcutEmote.emoteId.");
         }
      }
   }
}
