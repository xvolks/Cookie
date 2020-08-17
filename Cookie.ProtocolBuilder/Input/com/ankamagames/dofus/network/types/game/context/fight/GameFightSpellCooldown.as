package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class GameFightSpellCooldown implements INetworkType
   {
      
      public static const protocolId:uint = 205;
       
      
      public var spellId:int = 0;
      
      public var cooldown:uint = 0;
      
      public function GameFightSpellCooldown()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 205;
      }
      
      public function initGameFightSpellCooldown(param1:int = 0, param2:uint = 0) : GameFightSpellCooldown
      {
         this.spellId = param1;
         this.cooldown = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.spellId = 0;
         this.cooldown = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightSpellCooldown(param1);
      }
      
      public function serializeAs_GameFightSpellCooldown(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.spellId);
         if(this.cooldown < 0)
         {
            throw new Error("Forbidden value (" + this.cooldown + ") on element cooldown.");
         }
         param1.writeByte(this.cooldown);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightSpellCooldown(param1);
      }
      
      public function deserializeAs_GameFightSpellCooldown(param1:ICustomDataInput) : void
      {
         this._spellIdFunc(param1);
         this._cooldownFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightSpellCooldown(param1);
      }
      
      public function deserializeAsyncAs_GameFightSpellCooldown(param1:FuncTree) : void
      {
         param1.addChild(this._spellIdFunc);
         param1.addChild(this._cooldownFunc);
      }
      
      private function _spellIdFunc(param1:ICustomDataInput) : void
      {
         this.spellId = param1.readInt();
      }
      
      private function _cooldownFunc(param1:ICustomDataInput) : void
      {
         this.cooldown = param1.readByte();
         if(this.cooldown < 0)
         {
            throw new Error("Forbidden value (" + this.cooldown + ") on element of GameFightSpellCooldown.cooldown.");
         }
      }
   }
}
