package com.ankamagames.dofus.network.types.game.shortcut
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class ShortcutSmiley extends Shortcut implements INetworkType
   {
      
      public static const protocolId:uint = 388;
       
      
      public var smileyId:uint = 0;
      
      public function ShortcutSmiley()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 388;
      }
      
      public function initShortcutSmiley(param1:uint = 0, param2:uint = 0) : ShortcutSmiley
      {
         super.initShortcut(param1);
         this.smileyId = param2;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.smileyId = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ShortcutSmiley(param1);
      }
      
      public function serializeAs_ShortcutSmiley(param1:ICustomDataOutput) : void
      {
         super.serializeAs_Shortcut(param1);
         if(this.smileyId < 0)
         {
            throw new Error("Forbidden value (" + this.smileyId + ") on element smileyId.");
         }
         param1.writeVarShort(this.smileyId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ShortcutSmiley(param1);
      }
      
      public function deserializeAs_ShortcutSmiley(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._smileyIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ShortcutSmiley(param1);
      }
      
      public function deserializeAsyncAs_ShortcutSmiley(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._smileyIdFunc);
      }
      
      private function _smileyIdFunc(param1:ICustomDataInput) : void
      {
         this.smileyId = param1.readVarUhShort();
         if(this.smileyId < 0)
         {
            throw new Error("Forbidden value (" + this.smileyId + ") on element of ShortcutSmiley.smileyId.");
         }
      }
   }
}
